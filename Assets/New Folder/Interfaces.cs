using UnityEngine;


public interface ItakeDamage
{
    void RecibirDa�o(int cantidad);
}
public interface IAttack
    {
        void Atacar();
    }
    public interface IConsumible
    {
        void Consumir();
    }

    public interface IAplicarBuff
    {
        void AplicarBuff();
    }
    public interface IDropItem
    {
        void DropItem();
    }

