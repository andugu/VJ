#include <iostream>
#include <cmath>
#include <glm/gtc/matrix_transform.hpp>
#include "Scene.h"
#include <GL/glut.h>



void Scene::init(){
	currentLevel = 0;
	initShaders();
	initTextures();
	loadMenu();
	loadEnd();
	loadCredits();
	loadInstructions();
	state = GameState::MENU;
}

void Scene::loadMenu() {
	auto width = glutGet(GLUT_WINDOW_WIDTH);
	auto height = glutGet(GLUT_WINDOW_HEIGHT);
	projectionMatrix = glm::ortho(0.0f, float(width - 1), float(height - 1), 0.0f, 0.0f, 100.0f);
	menu.init(width, height);
}

void Scene::loadEnd() {
	auto width = glutGet(GLUT_WINDOW_WIDTH);
	auto height = glutGet(GLUT_WINDOW_HEIGHT);
	projectionMatrix = glm::ortho(0.0f, float(width - 1), float(height - 1), 0.0f, 0.0f, 100.0f);
	end.init(width, height);
}

void Scene::loadCredits() {
	auto width = glutGet(GLUT_WINDOW_WIDTH);
	auto height = glutGet(GLUT_WINDOW_HEIGHT);
	projectionMatrix = glm::ortho(0.0f, float(width - 1), float(height - 1), 0.0f, 0.0f, 100.0f);
	cred.init(width, height);
}

void Scene::loadInstructions() {
	auto width = glutGet(GLUT_WINDOW_WIDTH);
	auto height = glutGet(GLUT_WINDOW_HEIGHT);
	projectionMatrix = glm::ortho(0.0f, float(width - 1), float(height - 1), 0.0f, 0.0f, 100.0f);
	inst.init(width, height);
}

void Scene::restart() {
	if (!map.isRestarting()) {
		map.reset();
		--currentLevel;
	}
}


void Scene::loadLevel() {
	std::string fileName = LEVEL_FILE_NAME + std::to_string(currentLevel) + ".txt";
	map.free();
	
	auto width = glutGet(GLUT_WINDOW_WIDTH);
	auto height = glutGet(GLUT_WINDOW_HEIGHT);
	map = TileMap(width, height);
	map.init(fileName);
	projectionMatrix = glm::ortho(0.0f, float(width - 1), float(height - 1), 0.0f, 0.0f, 100.0f);
	currentTime = 0.0f;
}

void Scene::selectElement() {
	if (state == GameState::MENU) {
		int mode = menu.select();
		if (mode == 1) {
			loadLevel();
			state = GameState::GAMING;
		}
		else if (mode == 2) {
			state = GameState::INSTRUCTIONS;
		}
		else if (mode == 3) {
			state = GameState::CREDITS;
		}
	}
	else if (state == GameState::END) {
		int mode = end.select();
		if (mode == 1) {
			state = GameState::MENU;
		}
	}
	else if (state == GameState::INSTRUCTIONS) {
		int mode = inst.select();
		if (mode == 4) {
			state = GameState::MENU;
		}
	}
	else if (state == GameState::CREDITS) {
		int mode = cred.select();
		if (mode == 3) {
			state = GameState::MENU;
		}
		else {
			currentLevel = 7;
			loadLevel();
			state = GameState::GAMING;
		}
	}
}

void Scene::move(Direction const& direction) {
	if (state == GameState::MENU)
		menu.move(direction);
	else if (state == GameState::INSTRUCTIONS)
		inst.move(direction);
	else if (state == GameState::CREDITS)
		cred.move(direction);
	else
		map.movePlayerTiles(direction);
}

void Scene::update(int deltaTime){
	currentTime += deltaTime;
	std::cerr << currentLevel << std::endl;
	if (ServiceLocator::isGameEnd()) {
		if (currentLevel < MAX_LEVEL) {
			map.free();
			currentLevel++;
			loadLevel();
		}
		else if (currentLevel == MAX_LEVEL) {
			map.free();
			currentLevel = 0;
			state = GameState::END;
		}
		else if (currentLevel > MAX_LEVEL) {
			map.free();
			currentLevel = 0;
			state = GameState::CREDITS;
		}
	}
}

void Scene::render(){
	auto shaderManager = ServiceLocator::getShaderManager();
	glm::mat4 modelviewMatrix = glm::mat4(1.0f);
	
	shaderManager->use(ShaderManager::BACKGROUND_PROGRAM);
	shaderManager->setUniform("projectionMatrix", projectionMatrix);
	shaderManager->setUniform("modelViewMatrix", modelviewMatrix);

	if (state == GameState::MENU) {
		shaderManager->use(ShaderManager::TEXT_PROGRAM);
		shaderManager->setUniform("projectionMatrix", projectionMatrix);
		shaderManager->setUniform("modelViewMatrix", modelviewMatrix);
		menu.render();
	}

	else if (state == GameState::END) {
		shaderManager->use(ShaderManager::TEXT_PROGRAM);
		shaderManager->setUniform("projectionMatrix", projectionMatrix);
		shaderManager->setUniform("modelViewMatrix", modelviewMatrix);
		end.render();
	}

	else if (state == GameState::CREDITS) {
		shaderManager->use(ShaderManager::TEXT_PROGRAM);
		shaderManager->setUniform("projectionMatrix", projectionMatrix);
		shaderManager->setUniform("modelViewMatrix", modelviewMatrix);
		cred.render();
	}

	else if (state == GameState::INSTRUCTIONS) {
		shaderManager->use(ShaderManager::TEXT_PROGRAM);
		shaderManager->setUniform("projectionMatrix", projectionMatrix);
		shaderManager->setUniform("modelViewMatrix", modelviewMatrix);
		inst.render();
	}

	else {
		shaderManager->use(ShaderManager::TILE_PROGRAM);
		shaderManager->setUniform("projectionMatrix", projectionMatrix);
		shaderManager->setUniform("modelViewMatrix", modelviewMatrix);
		map.render();
	}
}


void Scene::initTextures() {
	ServiceLocator::getAnimationsManager()->init();
}


void Scene::initShaders(){
	ServiceLocator::getShaderManager()->init();
}

