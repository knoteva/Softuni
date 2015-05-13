<?php

class Navigation extends MainModel {

	/**
	 * Returns the navigation in the form of array of MySQL objects
	 *
	 * @return array
	 */
	public function load() {
		$pages = $this->db->query("SELECT * FROM pages WHERE status = 1");
		return $pages->fetchAll(PDO::FETCH_OBJ);
	}

}
