using Controllers;

namespace Interfaces
{
   public interface IStation
   {
      void HandlePlayerInteraction(PlayerController player);
      void ExecuteStationFunction();
   }
}
