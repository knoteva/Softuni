<?php

/**
 * MainModel
 */
class MainModel extends Db {

	/**
	 *
	 * @var \PDO
	 */
	protected $db;

	/**
	 * Constructor method of the MainModel
	 *
	 * Sets the $db property to a new PDO object
	 */
	public function __construct() {
		$this->db = new Db();
	}

}
