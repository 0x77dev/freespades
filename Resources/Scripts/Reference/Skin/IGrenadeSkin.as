/*
 Copyright (c) 2013 yvt

 This file is part of FreeSpades.

 FreeSpades is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 FreeSpades is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with FreeSpades.  If not, see <http://www.gnu.org/licenses/>.

 */

namespace spades {

    /**
     * A skin of grenades. A class that implements
     * this might also have to implement either IThirdPersonToolSkin
     * or IViewToolSkin.
     */
    interface IGrenadeSkin {
        /**
         * Receives a ready state. 0 = soon after placing a block,
         * >=1 = ready to place a block.
         */
        float ReadyState { set; }

        /**
         * Receives how long a player is cooking the grenade.
         * 0 if the player isn't cooking a grenade.
         */
        float CookTime { set; }
    }

}
