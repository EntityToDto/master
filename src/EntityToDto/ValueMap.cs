﻿namespace EntityToDto
{
    /// <summary>
    /// Facilitates mapping of DTO properties for simple types.
    /// </summary>
    /// <typeparam name="TDto">DTO type.</typeparam>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public abstract class ValueMap<TDto, TEntity> : IDtoMap<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        protected ValueMap(MappingDepth mappingDepth, TDto dto, TEntity entity)
        {
            MappingDepth = mappingDepth;
            Entity = entity;
            Dto = dto;
        }

        public MappingDepth MappingDepth { get; private set; }
        public TEntity Entity { get; private set; }
        public TDto Dto { get; private set; }

        /// <summary>
        /// Enables the <see cref="DtoMapVisitor{TDto, TEntity}"/> to map DTO properties for simple types.
        /// </summary>
        /// <param name="visitor">The visitor object that contains DTO mapping logic.</param>
        public abstract void Accept(DtoMapVisitor<TDto, TEntity> visitor);
    }
}
