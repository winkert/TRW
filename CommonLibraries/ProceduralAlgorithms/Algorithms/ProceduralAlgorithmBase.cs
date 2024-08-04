using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class ProceduralAlgorithmCallbackEventArgs : EventArgs
    {
        public double DelayInSeconds { get; set; }
    }

    public delegate void ProceduralAlgorithmCallbackEvent(object sender, ProceduralAlgorithmCallbackEventArgs e);
    public abstract class ProceduralAlgorithmBase<M, C> where C : ICell where M : IMatrix<C>
    {
        private object _sender;
        protected M _grid;
        protected int _xDimension;
        protected int _yDimension;
        private Random _r;
        protected Random R
        {
            get
            {
                if (_r == null)
                {
                    _r = new Random();
                }
                return _r;
            }
        }


        /// <summary>
        /// Event to fire when a step is made in the procedural generation
        /// </summary>
        public event ProceduralAlgorithmCallbackEvent Callback;
        public ProceduralAlgorithmBase(object sender, M grid, int xDim, int yDim)
        {
            _sender = sender;
            _grid = grid;
            _xDimension = xDim;
            _yDimension = yDim;
        }

        public void DoAlgorithm(params object[] args)
        {
            if (!ValidParameters(args))
            {
                throw new ArgumentException();
            }
            DoAlgorithmInternal(args);
        }

        protected void InvokeCallback(double delay)
        {
            Callback?.Invoke(_sender, new ProceduralAlgorithmCallbackEventArgs() { DelayInSeconds = delay });
        }
        protected decimal GetNextDecimal(decimal spread)
        {
            return R.NextDecimal() * spread;
        }


        protected ICell GetNeighborFromAngle(ICell cell, double angle)
        {
            Vector direction = StaticRoutines.GetAngleVector(angle);
            ICell targetNeighbor = cell.GetNeighborByVector(direction);

            return targetNeighbor;
        }


        protected bool ValidParameters(params object[] args)
        {
            if (args.Count() != NumberOfParamters)
                return false;
            for (int i = 0; i < NumberOfParamters; i++)
            {
                object arg = args[i];
                if (!(arg.GetType().Equals(TypesOfParameters[i])))
                    return false;
            }
            return true;
        }

        #region Abstract
        public abstract int NumberOfParamters { get; }
        public abstract Type[] TypesOfParameters { get; }
        protected abstract void DoAlgorithmInternal(params object[] args);

        #endregion

    }
}
