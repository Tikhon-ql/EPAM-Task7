ALTER TABLE [dbo].[WorkResult]  WITH CHECK ADD CONSTRAINT [FK_dbo.WorkResult_dbo.Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WorkResult] CHECK CONSTRAINT [FK_dbo.WorkResult_dbo.Student_StudentId]
GO
--2
ALTER TABLE [dbo].[WorkResult]  WITH CHECK ADD CONSTRAINT [FK_dbo.WorkResult_dbo.Subject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WorkResult] CHECK CONSTRAINT [FK_dbo.WorkResult_dbo.Subject_SubjectId]
GO
--3
ALTER TABLE [dbo].[WorkResult]  WITH CHECK ADD CONSTRAINT [FK_dbo.WorkResult_dbo.WorkType_WorkTypeId] FOREIGN KEY([WorkTypeId])
REFERENCES [dbo].[WorkType] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WorkResult] CHECK CONSTRAINT [FK_dbo.WorkResult_dbo.WorkType_WorkTypeId]
GO
--4
ALTER TABLE [dbo].[WorkResult]  WITH CHECK ADD CONSTRAINT [FK_dbo.WorkResult_dbo.SessionShedule_SessionSheduleId] FOREIGN KEY([SessionSheduleId])
REFERENCES [dbo].[SessionShedule] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WorkResult] CHECK CONSTRAINT [FK_dbo.WorkResult_dbo.SessionShedule_SessionSheduleId]
GO