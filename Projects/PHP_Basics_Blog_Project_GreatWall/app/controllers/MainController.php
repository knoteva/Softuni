<?php

/**
 * MainController
 *
 * Each other controller should extend the MainController
 */
class Main {

	/**
	 * Returns a new model object.
	 *
	 * @param string $model
	 * @return \model
	 */
	protected function getModel($model) {
		return new $model;
	}

	/**
	 * Performs 'require_once' action and gets the specified view.
	 * Provides the navigation as array, visible from every view
	 *
	 * @param string $view
	 * @param array $data
	 */
	protected function getView($view, $data = []) {
		$nav = (new Navigation())->load();
		require_once Config::get('paths', 'views') . $view . '.php';
	}

}