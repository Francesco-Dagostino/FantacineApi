using System;

namespace Domain.Enums
{
    public enum MovieStatus
    {
        Disponible,
        EnProyeccion,
        Retirada
    }
    public enum UserRole
    {
        Client,
        Admin,
        SuperAdmin
    }
    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Horror,
        Romance,
        SciFi,
        Documentary,
        Thriller,
        Animation
    }
    public enum SubscriptionType
    {
        Free,
        Basic,
        Premium,
        VIP
    }
}
