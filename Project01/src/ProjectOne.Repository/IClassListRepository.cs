namespace ProjectOne.Repository
{
    public interface IClassListRepository
    {
        ClassListModel[] ClassList { get; }
        ClassListModel GetClassList(int classId);
    }
}
