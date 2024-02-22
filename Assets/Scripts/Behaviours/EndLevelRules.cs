using Helpers.Observer;
using GameUI;

namespace Behaviours
{
    class EndLevelRules : IEventListener<SnakeEvent>
    {
        public EndLevelRules()
        {
            this.EventStartListening();
        }
        ~EndLevelRules()
        {
            this.EventStopListening();
        }
        private void OpenEndGameUI()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.EndGameMenu);
        }
        public void OnEventTrigger(SnakeEvent eventType)
        {
            if (eventType.IsDead)
            {
                OpenEndGameUI();
            }
        }
    }
}
