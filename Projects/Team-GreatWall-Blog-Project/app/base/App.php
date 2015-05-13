<?php

class App {

	private static $instance;
	private $controller = "Home";
	private $method = "index";
	private $params = [];

	/**
	 * Private __contruct()
	 */
	private function __construct() {}

	/**
	 * Returns the singleton App instance.
	 *
	 * @return App
	 */
	public function getInstance() {
		if (!isset(self::$instance)) {
			self::$instance = new App();
		}

		return self::$instance;
	}

	/**
	 * Plays the role of a Front Controller.
	 */
	public function run() {
		// Get the url
		$url = $this->parseUrl();

		if (isset($url[0]) && ucfirst($url[0]) != 'Main') {
			if (file_exists(Config::get('paths', 'controllers') . ucfirst($url[0]) . 'Controller.php')) {
				// If the controller exists => change the default controller.
				$this->controller = ucfirst($url[0]);

				// Remove the controller from the url array.
				unset($url[0]);
			}
		}

		require_once Config::get('paths', 'controllers') . $this->controller . 'Controller.php';

		// Create a new controller object.
		// This gives us access to the methods of this controller.
		$this->controller = new $this->controller;

		if (isset($url[1])) {
			if (method_exists($this->controller, $url[1])) {
				// If this controller has the provided method...
				$this->method = $url[1];
				unset($url[1]);
			}
		}

		if (!empty($url)) {
			// And if the user provided some parameters for this method....
			$this->params = array_values($url);
		}

		// Call the method with these parameters.
		call_user_func([$this->controller, $this->method], $this->params);
	}

	/**
	 * Parses the given URL.
	 *
	 * @return array Contains the controller and the method and params, if given any.
	 */
	private function parseUrl() {
		if (isset($_GET['url'])) {
			$url = $_GET['url'];
			$_url = explode('/', filter_var(rtrim($url, '/'), FILTER_SANITIZE_URL));
			return $_url;
		}

		return false;
	}

	/**
	 * Autoloader
	 * Searches for classes in
	 *     - base/
	 *     - controllers/
	 *     - models/
	 *     - views/
	 */
	public function autoLoad() {
		spl_autoload_register(function ($class) {
			$base = "../app/base/" . $class . ".php";
			$controller = Config::get("paths", "controllers") . ucfirst($class) . "Controller.php";
			$model = Config::get("paths", "models") . $class . ".php";
			$view = Config::get("paths", "views") . $class . ".php";

			if (file_exists($controller)) {
				require_once $controller;
			} else if (file_exists($base)) {
				require_once $base;
			} else if (file_exists($model)) {
				require_once $model;
			} else if (file_exists($view)) {
				require_once $view;
			}
		});
	}

}
