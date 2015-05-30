<?php

class Config {

	/**
	 * Get a value from the config.php file.
	 * Provide nothing as a params to the function, and get the whole config array.
	 *
	 * @param string $params Each level of the config array must be a separate string.
	 * @return string/boolean
	 */
	public static function get($params = null) {
		$cnf = self::fetchConfig();
		$args = func_get_args();

		if ($params == null) {
			return $cnf;
		}

		for ($currArg = 0; $currArg < count($args); $currArg++) {
			if (array_key_exists($args[$currArg], $cnf)) {
				$cnf = $cnf[$args[$currArg]];

				if ($currArg == count($args) - 1 && !is_array($cnf)) {
					return $cnf;
				}
			} else {
				return false;
			}
		}

		return false;
	}

	/**
	 * Returns the configuration array.
	 *
	 * @return array $cnf The config array.
	 */
	private static function fetchConfig() {

		////////////////////
		// Config array //
		////////////////////
		preg_match('/.+public\//', $_SERVER['REQUEST_URI'], $match);

		$publicFolder = implode('', $match);

		$cnf = [
			"db" => [
				"host" => "localhost",
				"dbuser" => "root",
				"dbpass" => "",
				"dbname" => "great_wall_blog",
			],

			"paths" => [
				////////////////////////////////////////////////////
				// TODO: ON DEPLOYMENT: "root => '/'" !!!!!!!!!!! //
				////////////////////////////////////////////////////
				"root" => $publicFolder,
				"controllers" => "../app/controllers/",
				"models" => "../app/models/",
				"views" => "../app/views/",
				"incl" => "../app/incl/",
			],

		];

		/////
		// //
		/////
		return $cnf;
	}

}