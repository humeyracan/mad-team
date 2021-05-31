using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Shared.BaseTypes
{
        public static class ApplicationConfig
        {
            private static readonly ApplicationSetting _settings;

            static ApplicationConfig()
            {
                try
                {
                    var settingFile = "C:\\Users\\can.kayi\\Source\\Repos\\make-a-difference-team\\NoMoreException\\NoMoreException" + "/settings.xml";
                    var doc = new XmlDocument();
                    doc.Load(settingFile);
                    XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSetting));
                    using (TextReader reader = new StringReader(doc.InnerXml))
                    {
                        _settings = (ApplicationSetting)serializer.Deserialize(reader);
                    }
                
                }
                catch(Exception ex)
                {
                    _settings = new ApplicationSetting();
                }
            }

            public static void Start()
            {
                RegisterAndRunPlugins();
            }

            static void RegisterAndRunPlugins()
            {
                if (_settings!=null && _settings.PluginSettings != null)
                {
                    foreach (var plugin in _settings.PluginSettings)
                    {
                        var type = Type.GetType(plugin.Assembly);
                        if (type != null)
                        {
                            var exec = (IPluggable)Activator.CreateInstance(type);
                            exec.Register();
                        }
                    }

                    foreach (var plugin in _settings.PluginSettings)
                    {
                        var type = Type.GetType(plugin.Assembly);
                        if (type != null)
                        {
                            var exec = (IPluggable)Activator.CreateInstance(type);
                            exec.Run();
                        }
                    }
                }
            }


           
        }

        public class ApplicationSetting
        {
            [XmlArray("Plugins")]
            [XmlArrayItem("Plugin")]
            public PluginSetting[] PluginSettings { get; set; }

        }

        public class PluginSetting
        {
            public string Name { get; set; }
            public string Assembly { get; set; }
        }


    

}
