USE [TeamPlayersDB]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'User', N'USER', N'USER')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'Admin', N'ADMIN', N'ADMIN')
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([countryId], [countryName]) VALUES (1, N'Egypt')
INSERT [dbo].[Countries] ([countryId], [countryName]) VALUES (2, N'Spain')
INSERT [dbo].[Countries] ([countryId], [countryName]) VALUES (3, N'Portgual')
INSERT [dbo].[Countries] ([countryId], [countryName]) VALUES (4, N'France')
SET IDENTITY_INSERT [dbo].[Countries] OFF
