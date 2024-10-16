namespace AMS.UI.View_Models.Interfaces
{
    internal interface IEntityViewModal<TEntity> : IViewModel
    {
        TEntity ToEntity();
    }
}
