using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Util
{
    public class EventLogger
    {

        /// <summary>
        /// Escribe el log en el log de eventos de windows
        /// </summary>
        /// <param name="source">fuente del Log sobre el que se va a escribir Ej: Nombre de la App</param>
        /// <param name="log">Log sobre el que se va a escribir. Ej: Application</param>
        /// <param name="strEvent">Evento a escribir en el log</param>
        /// /// <param name="logType">Tipo de evento</param>
        public static void WriteLog(string strEvent, EventLogEntryType logType)
        {
            string source, log;
            //lee el source y el log del .config
            source = ConfigurationManager.AppSettings["LogSource"];
            log = ConfigurationManager.AppSettings["LogName"];

            //Si no existe la fuente la crea.
            if (!EventLog.SourceExists(source))
                EventLog.CreateEventSource(source, log);
            //Escribe el log
            EventLog.WriteEntry(source, strEvent, logType);
        }
    }
}
