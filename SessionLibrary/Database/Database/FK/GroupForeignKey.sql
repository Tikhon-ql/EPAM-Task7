ALTER TABLE [dbo].[Group]  WITH CHECK ADD CONSTRAINT [FK_dbo.Group_dbo.Specification_SpecificationId] FOREIGN KEY([SpecificationId])
REFERENCES [dbo].[Specification] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_dbo.Group_dbo.Specification_SpecificationId]
GO