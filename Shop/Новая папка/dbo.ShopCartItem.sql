CREATE TABLE [dbo].[ShopCartItem] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [carid]      INT            NULL,
    [price]      BIGINT         NOT NULL,
    [ShopCartId] NVARCHAR (MAX) NULL,
    [count] INT NULL, 
    CONSTRAINT [PK_ShopCartItem] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_ShopCartItem_Car_carid] FOREIGN KEY ([carid]) REFERENCES [dbo].[Car] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ShopCartItem_carid]
    ON [dbo].[ShopCartItem]([carid] ASC);

