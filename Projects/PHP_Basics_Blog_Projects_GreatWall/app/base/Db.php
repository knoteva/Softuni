<?php

class Db extends PDO {

	/**
	 * Returns PDO
	 *
	 * @return \PDO
	 */
	public function __construct() {
		parent::__construct('mysql:host=' . Config::get('db', 'host') . ';dbname=' . Config::get('db', 'dbname'), Config::get('db', 'dbuser'), Config::get('db', 'dbpass'));
		parent::query('SET NAMES utf8');
	}

}
