namespace my_games_list_back.Data
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        protected BaseEntity() { }

        public BaseEntity(Guid id, bool isActive, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
