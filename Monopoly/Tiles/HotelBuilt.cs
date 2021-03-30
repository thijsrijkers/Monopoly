﻿using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class HotelBuilt : Tile, Buildable
    {
        private Buildable tile;

        public HotelBuilt(Buildable tile) : base(null)
        {
            this.tile = tile;
        }

        public int getPrice()
        {
            return this.tile.getPrice() * 2;
        }

        public int getAmountOfHouses()
        {
            return this.tile.getAmountOfHouses();
        }

        public Boolean hasHotel() {
            return true;
        }

        public void SetOwner(PlayerObject value)
        {
            tile.SetOwner(value);
        }

        public PlayerObject GetOwner()
        {
            return this.tile.GetOwner();
        }
    }
}
