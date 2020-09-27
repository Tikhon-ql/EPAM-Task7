ALTER TABLE [dbo].[Session]  WITH CHECK ADD CONSTRAINT [FK_dbo.Session_dbo.SessionType_SessionTypeId] FOREIGN KEY([SessionTypeId])
REFERENCES [dbo].[SessionType] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_dbo.Session_dbo.SessionType_SessionTypeId]
GO