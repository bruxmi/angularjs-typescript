-- ConnectionString
INSERT [dbo].[ConnectionString] ([Name], [Value], [ProviderName]) VALUES (N'AppSettingContext', N'Server=(localdb)\ProjectsV12; Database=Debug.AppSettingContext; Trusted_Connection=True; Timeout=60; MultipleActiveResultSets=True;', N'System.Data.SqlClient')
INSERT [dbo].[ConnectionString] ([Name], [Value], [ProviderName]) VALUES (N'WebApiTypeScriptContext', N'Server=(localdb)\ProjectsV12; Database=Debug.WebApiTypeScriptContext; Trusted_Connection=True; Timeout=60; MultipleActiveResultSets=True;', N'System.Data.SqlClient')

-- ApplicationSetting
INSERT [dbo].[ApplicationSetting] ([Key], [Value]) VALUES (N'LogLevel', N'Debug')
INSERT [dbo].[ApplicationSetting] ([Key], [Value]) VALUES (N'LogMode', N'Database')
INSERT [dbo].[ApplicationSetting] ([Key], [Value]) VALUES (N'LogDatabaseBufferSize', N'1')
INSERT [dbo].[ApplicationSetting] ([Key], [Value]) VALUES (N'LogDatabaseConnectionType', N'System.Data.SqlClient.SqlConnection, System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089')