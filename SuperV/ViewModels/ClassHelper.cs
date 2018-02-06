using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperV.ViewModels
{
    public class ClassHelper
    {
        /// <summary>
        /// Restituisce il nome della classe CSS che esprime il colore del riquadro della macchina in relazione allo stato della macchina.
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static string  GetBackgroundClass(int Status)
        {
            switch (Status)
            {
                case 0:
                    return Constants.BG_COLOR_DISCONNECTED;
                case 1:
                    return Constants.BG_COLOR_EMERGENCY;
                case 2:
                    return Constants.BG_COLOR_ALARM;
                case 3:
                    return Constants.BG_COLOR_RUN;
                case 4:
                    return Constants.BG_COLOR_RUN_ALARM;
                case 5:
                    return Constants.BG_COLOR_STOPPED_STATUS;
                case 6:
                    return Constants.BG_COLOR_SETUP;
                case 7:
                    return Constants.BG_COLOR_STARTUP;
                case 8:
                    return Constants.BG_COLOR_CLEAN;
                case 13:
                    return Constants.BG_COLOR_09_NAV;
                case 14:
                    return Constants.BG_COLOR_07_CLEAN;
                case 15:
                    return Constants.BG_COLOR_02_COLOR;
                case 16:
                    return Constants.BG_COLOR_01_CHANGE;
                case 21:
                    return Constants.BG_COLOR_21_SETUP;
                case 253:
                    return Constants.BG_COLOR_99_PRODUCTION;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Restituisce il nome della classe CSS che esprime il colore della striscia nel riquadro della macchina in relazione allo stato della macchina.
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static string GetBackgroundStripeClass(int Status)
        {
            switch (Status)
            {
                case 0:
                    return Constants.BG_COLOR_DISCONNECTED_STRIPE;
                case 1:
                    return Constants.BG_COLOR_EMERGENCY_STRIPE;
                case 2:
                    return Constants.BG_COLOR_ALARM_STRIPE;
                case 3:
                    return Constants.BG_COLOR_RUN_STRIPE;
                case 4:
                    return Constants.BG_COLOR_RUN_ALARM_STRIPE;
                case 5:
                    return Constants.BG_COLOR_STOPPED_STATUS_STRIPE;
                case 6:
                    return Constants.BG_COLOR_SETUP_STRIPE;
                case 7:
                    return Constants.BG_COLOR_STARTUP_STRIPE;
                case 8:
                    return Constants.BG_COLOR_CLEAN_STRIPE;
                case 13:
                    return Constants.BG_COLOR_09_NAV_STRIPE;
                case 14:
                    return Constants.BG_COLOR_07_CLEAN_STRIPE;
                case 15:
                    return Constants.BG_COLOR_02_COLOR_STRIPE;
                case 16:
                    return Constants.BG_COLOR_01_CHANGE_STRIPE;
                case 21:
                    return Constants.BG_COLOR_21_SETUP_STRIPE;
                case 253:
                    return Constants.BG_COLOR_99_PRODUCTION_STRIPE;
                default:
                    return string.Empty;
            }
        }
    }
}