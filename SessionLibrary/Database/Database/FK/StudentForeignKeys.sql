ALTER TABLE [dbo].[Student]  WITH CHECK ADD CONSTRAINT [FK_dbo.Student_dbo.Group_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_dbo.Student_dbo.Group_GroupId]
GO
--2
ALTER TABLE [dbo].[Student]  WITH CHECK ADD CONSTRAINT [FK_dbo.Student_dbo.Gender_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_dbo.Student_dbo.Gender_GenderId]
GO