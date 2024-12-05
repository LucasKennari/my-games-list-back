namespace my_games_list_back.Data
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        public bool IsActive { get; protected set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        protected BaseEntity() { }

        public BaseEntity(Guid id, bool isActive, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public void SetIsActive(bool flag)
        {
            IsActive = flag;
        }
    }
}
