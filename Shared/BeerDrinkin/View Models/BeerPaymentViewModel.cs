using System;
using System.Collections.Generic;
using System.Linq;
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin
{
    public class BeerPaymentViewModel
    {
        public BeerPaymentViewModel ()
        {
            _beerBasket = new Dictionary<BeerItem, int> ();
        }

        private Dictionary<BeerItem,int> _beerBasket;

        public Dictionary<BeerItem,int> BeerBasket { get { return _beerBasket; } }

        public void AddItem (BeerItem beer, int quanity)
        {
            if (_beerBasket.ContainsKey (beer)) {
                _beerBasket [beer] += _beerBasket [beer];
            } else {
                _beerBasket.Add (beer, quanity);
            }
        }

        public void RemoveItem (BeerItem beer, int quanity, bool all)
        {
            if (_beerBasket.ContainsKey (beer)) {
                if (all) {
                    _beerBasket.Remove (beer); 
                } else {
                    _beerBasket [beer] -= quanity;
                    if (_beerBasket [beer] <= 0) {
                        _beerBasket.Remove (beer); 
                    }
                }
            } 
        }

        public decimal GetSubTotal ()
        {
            Decimal subTotal = 0;
            if (_beerBasket.Count == 0) {
                return subTotal;
            } else {
                
                foreach (KeyValuePair<BeerItem,int> item in _beerBasket.ToList ()) {
                    subTotal += Decimal.Parse (item.Key.Price) * item.Value;
                }
                return subTotal;
            }
        }
    }
}

