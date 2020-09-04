﻿using CourseProject.BusinessLogic.Services.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class LoggerService : ILoggerService
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerService() { }
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
