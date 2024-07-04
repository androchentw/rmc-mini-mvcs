using RMC.Mini.Experimental.ContextLocators;
using RMC.Mini.Samples.RollABall.WithMini.Mini.View;
using UnityEngine;
using UnityEngine.Assertions;

namespace RMC.Mini.Samples.RollABall.WithMini.Mini
{
    /// <summary>
    /// The Example is the main entry point to the demo
    /// </summary>
    public class RollABallMiniExample : MonoBehaviour
    {
        
        //  Fields ----------------------------------------
        [SerializeField] 
        private InputView _inputView;

        [SerializeField] 
        private PlayerView _playerView;

        [SerializeField] 
        private UIView _uiView;

        private RollABallSimpleMini _rollABallSimpleMini;
        //  Unity Methods  --------------------------------
        protected void Start()
        {
            _rollABallSimpleMini = 
                new RollABallSimpleMini(_inputView, _playerView, _uiView);
            
            // This demo is rare. It needs a special type of context.
            Assert.IsNotNull(_rollABallSimpleMini.Context as ContextWithLocator, 
                "This demo requires a ContextWithLocator.");

            _rollABallSimpleMini.Initialize();
        }

        protected void OnDestroy()
        {
            if (_rollABallSimpleMini == null)
            {
                return;
            }
            _rollABallSimpleMini.Dispose();
        }
        
        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}