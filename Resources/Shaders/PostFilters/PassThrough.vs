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



attribute vec2 positionAttribute;
uniform vec4 colorUniform;

uniform vec4 texCoordRange;

varying vec4 color;
varying vec2 texCoord;

void main() {
	
	vec2 pos = positionAttribute;
	
	vec2 scrPos = pos * 2. - 1.;
	
	gl_Position = vec4(scrPos, 0.5, 1.);
	
	color = colorUniform;
	texCoord = pos * texCoordRange.zw + texCoordRange.xy;
}

