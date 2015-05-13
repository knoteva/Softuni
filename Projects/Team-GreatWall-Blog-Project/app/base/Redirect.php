<?php

/**
 * Redirect class.
 */
class Redirect {

	/**
	 * Redirects the user to a specific location.
	 * Use 'homepage' to redirect to the homepage.
	 *
	 * @param string $location
	 */
	public static function to($location = 'homepage') {
		if ($location == 'homepage') {
			header('Location: ' . Config::get('paths', 'root'));
		} else {
			header('Location: ' . Config::get('paths', 'root') . $location);
		}
	}

}