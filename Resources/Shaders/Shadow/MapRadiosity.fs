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

/**** CPU RADIOSITY (FASTER?) *****/

uniform sampler3D ambientShadowTexture;
uniform sampler3D radiosityTextureFlat;
uniform sampler3D radiosityTextureX;
uniform sampler3D radiosityTextureY;
uniform sampler3D radiosityTextureZ;
varying vec3 radiosityTextureCoord;
varying vec3 ambientShadowTextureCoord;
varying vec3 normalVarying;
uniform vec3 ambientColor;
uniform vec3 fogColor;

vec3 DecodeRadiosityValue(vec3 val){
	// reverse bias
	val *= 1023. / 1022.;
	val = (val * 2.) - 1.;
	return val;
}

vec3 Radiosity_Map(float detailAmbientOcclusion, float ssao) {
	vec3 col = DecodeRadiosityValue
	(texture3D(radiosityTextureFlat,
			   radiosityTextureCoord).xyz);
	vec3 normal = normalize(normalVarying);
	col += normal.x * DecodeRadiosityValue
	(texture3D(radiosityTextureX,
			   radiosityTextureCoord).xyz);
	col += normal.y * DecodeRadiosityValue
	(texture3D(radiosityTextureY,
			   radiosityTextureCoord).xyz);
	col += normal.z * DecodeRadiosityValue
	(texture3D(radiosityTextureZ,
			   radiosityTextureCoord).xyz);
	col = max(col, 0.);
	col *= 1.5 * ssao;

	detailAmbientOcclusion *= ssao;

	// ambient occlusion
	float amb = texture3D(ambientShadowTexture, ambientShadowTextureCoord).x;
	amb = max(amb, 0.); // for some reason, mainTexture value becomes negative

	// mix ambient occlusion values generated by two different methods somehow
	amb = mix(sqrt(amb * detailAmbientOcclusion), min(amb, detailAmbientOcclusion), 0.5);

	amb *= .8 - normalVarying.z * .2;
	col += amb * ambientColor;

	return col;
}

vec3 BlurredReflection_Map(float detailAmbientOcclusion, vec3 direction, float ssao) {
	vec3 col = DecodeRadiosityValue
	(texture3D(radiosityTextureFlat,
			   radiosityTextureCoord).xyz);
	vec3 normal = normalize(normalVarying);
	col += normal.x * DecodeRadiosityValue
	(texture3D(radiosityTextureX,
			   radiosityTextureCoord).xyz);
	col += normal.y * DecodeRadiosityValue
	(texture3D(radiosityTextureY,
			   radiosityTextureCoord).xyz);
	col += normal.z * DecodeRadiosityValue
	(texture3D(radiosityTextureZ,
			   radiosityTextureCoord).xyz);
	col = max(col, 0.);
	col *= 1.5 * ssao;

	detailAmbientOcclusion *= ssao;

	// ambient occlusion
	float amb = texture3D(ambientShadowTexture, ambientShadowTextureCoord).x;
	amb = max(amb, 0.); // for some reason, mainTexture value becomes negative
	amb *= amb; // darken

	// mix ambient occlusion values generated by two different methods somehow
	amb = mix(sqrt(amb * detailAmbientOcclusion), min(amb, detailAmbientOcclusion), 0.5);

	amb *= .8 - normalVarying.z * .2;

	return col + fogColor * amb;
}
