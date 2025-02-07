﻿using GameServerManager.Models;
using GameServerManager.Models.Request;
using GameServerManager.Models.Servers;
using ICOM.TGSM.Service.Agent.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICOM.TGSM.Service.Agent
{
    public class SteamCMDService
    {
        private ProcessService _ps { get; set; }

        public SteamCMDService(ProcessService ps)
        {
            _ps = ps;
        }

        public async Task<bool> DownloadSteamClient()
        {
            try
            {
                if (!FileHelper.CheckDirectoryExists(GlobalConstants.SteamCommandPath))
                {
                    FileHelper.CreateDirectory(GlobalConstants.SteamCommandPath);
                }

                if (!FileHelper.CheckFileExists(GlobalConstants.SteamCommandPath + "\\steamcmd.exe"))
                {
                    using (var client = new HttpClient())
                    {
                        byte[] fileBytes = await client.GetByteArrayAsync(new Uri("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip"));
                        File.WriteAllBytes(GlobalConstants.SteamCommandPath + "\\steamcmd.zip", fileBytes);
                    }
                    ZipFile.ExtractToDirectory(GlobalConstants.SteamCommandPath + "\\steamcmd.zip", GlobalConstants.SteamCommandPath, true);
                    File.Delete(GlobalConstants.SteamCommandPath + "\\steamcmd.zip");
                }
            }
            catch (Exception)
            {
                throw new IOException("Could not download steamCMD.");
            }

            return true;
        }

        public RunningProcess ExecuteSteamCMDRequest(SteamCMDRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.DownloadPath))
            {
                if (!FileHelper.CheckDirectoryExists(request.DownloadPath))
                {
                    FileHelper.CreateDirectory(request.DownloadPath);
                }

                var procReq = new ProcessRequest
                {
                    ExecutablePath = request.SteamCMDPath,
                    WorkingDir = GlobalConstants.SteamCommandPath,
                    Arguments = request.GetSteamCMDArguments(),
                };

                return _ps.StartProcess(procReq);
            }

            return null;
        }

        public bool CheckSteamClientExists()
        {
            return FileHelper.CheckFileExists(GlobalConstants.SteamCommandPath + "\\steamcmd.exe");
        }

    }
}
