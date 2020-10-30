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

#pragma once

#include <map>
#include <vector>

namespace spades {
	class Bitmap;
	class BitmapAtlasGenerator {
	public:
		struct Item {
			Bitmap *bitmap;
			int x, y, w, h;
		};
		struct Result {
			std::vector<Item> items;
			Bitmap *bitmap;
		};

	private:
		std::vector<Bitmap *> bmps;
		int MinRectSize();
		int MinWidth();
		int MinHeight();

	public:
		BitmapAtlasGenerator();
		~BitmapAtlasGenerator();

		void AddBitmap(Bitmap *);
		Result Pack();
	};
}
