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

#include <vector>

#include "GLProgramUniform.h"

namespace spades {
	namespace draw {
		class GLRenderer;
		class GLProgramManager;
		class IGLShadowMapRenderer;
		struct GLShadowMapRenderParam;
		class GLShadowMapShader {
			GLProgramUniform projectionViewMatrix;

		public:
			GLShadowMapShader();
			~GLShadowMapShader() {}

			static std::vector<GLShader *> RegisterShader(GLProgramManager *);

			static IGLShadowMapRenderer *CreateShadowMapRenderer(GLRenderer *);

			/** setups shadow map shader.
			 * note that this function sets the current active texture
			 * stage to the returned texture stage.
			 * @param firstTexStage first available texture stage.
			 * @return next available texture stage */
			int operator()(GLRenderer *renderer, GLProgram *, int firstTexStage);
		};
	}
}