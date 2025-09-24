IF NOT EXISTS (SELECT 1 FROM dbo.Criticalities WHERE Criticality = N'Baixo')
    INSERT INTO dbo.Criticalities (Criticality, CreatedAt) VALUES (N'Baixo', SYSDATETIMEOFFSET());

IF NOT EXISTS (SELECT 1 FROM dbo.Criticalities WHERE Criticality = N'Médio')
    INSERT INTO dbo.Criticalities (Criticality, CreatedAt) VALUES (N'Médio', SYSDATETIMEOFFSET());

IF NOT EXISTS (SELECT 1 FROM dbo.Criticalities WHERE Criticality = N'Alto')
    INSERT INTO dbo.Criticalities (Criticality, CreatedAt) VALUES (N'Alto', SYSDATETIMEOFFSET());

IF NOT EXISTS (SELECT 1 FROM dbo.Criticalities WHERE Criticality = N'Crítico')
    INSERT INTO dbo.Criticalities (Criticality, CreatedAt) VALUES (N'Crítico', SYSDATETIMEOFFSET());

IF NOT EXISTS (SELECT 1 FROM dbo.Status WHERE Status = N'Aberto')
    INSERT INTO dbo.Status (Status, CreatedAt) VALUES (N'Aberto', SYSDATETIMEOFFSET());

IF NOT EXISTS (SELECT 1 FROM dbo.Status WHERE Status = N'Atribuído')
    INSERT INTO dbo.Status (Status, CreatedAt) VALUES (N'Atribuído', SYSDATETIMEOFFSET());

IF NOT EXISTS (SELECT 1 FROM dbo.Status WHERE Status = N'Em Atendimento')
    INSERT INTO dbo.Status (Status, CreatedAt) VALUES (N'Em Atendimento', SYSDATETIMEOFFSET());

IF NOT EXISTS (SELECT 1 FROM dbo.Status WHERE Status = N'Em Validação')
    INSERT INTO dbo.Status (Status, CreatedAt) VALUES (N'Em Validação', SYSDATETIMEOFFSET());

IF NOT EXISTS (SELECT 1 FROM dbo.Status WHERE Status = N'Fechado')
    INSERT INTO dbo.Status (Status, CreatedAt) VALUES (N'Fechado', SYSDATETIMEOFFSET());

IF NOT EXISTS (SELECT 1 FROM dbo.Status WHERE Status = N'Cancelado')
    INSERT INTO dbo.Status (Status, CreatedAt) VALUES (N'Cancelado', SYSDATETIMEOFFSET());
