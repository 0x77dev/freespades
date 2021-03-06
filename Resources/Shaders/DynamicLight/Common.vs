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



uniform vec3 dynamicLightOrigin;
uniform mat4 dynamicLightSpotMatrix;

void PrepareForShadow_Map(vec3 vertexCoord) ;


varying vec3 lightPos;
varying vec3 lightNormal;
varying vec3 lightTexCoord;

void PrepareForDynamicLightNoBump(vec3 vertexCoord, vec3 normal) {
	PrepareForShadow_Map(vertexCoord);
	
	lightPos = dynamicLightOrigin - vertexCoord;
	lightNormal = normal;
	
	// projection
	lightTexCoord = (dynamicLightSpotMatrix * vec4(vertexCoord,1.)).xyw;
					 
}

// TODO: bumpmapping variant (requires tangent vector)
