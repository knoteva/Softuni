<?php

/**
 * PageModel
 */
class PageModel extends MainModel {

	/**
	 * Gets the information about the page, specified by id, from the Database
	 *
	 * @param  int $id The id of the page
	 * @return array
	 */
	public function open($id) {
		if (!empty($id)) {
			$query = $this->db->prepare('SELECT * FROM pages WHERE id=:id');
			$query->execute([':id' => $id]);
			return $query->fetchAll(PDO::FETCH_OBJ);
		}
	}

	/**
	 * Returns all the pages.
	 * 
	 * @return array
	 */
	public function getAll() {
		$pages = $this->db->query('SELECT * FROM pages');
		$pages = $pages->fetchAll(PDO::FETCH_OBJ);
		return $pages;
	}

	/**
	 * Inserts a new page in the database.
	 *
	 * @return boolean
	 */
	public function add() {
		$pageStatus = empty($_POST['pageStatus']) ? 0 : $_POST['pageStatus'];
		if(!empty($_POST['pageTitle']) && !empty($_POST['pageContent'])) {
			$stmt = $this->db->prepare('INSERT INTO pages(title, content, status) VALUES(:title, :content, :status)');
			return $stmt->execute([
				':title' => $_POST['pageTitle'],
				':content' => $_POST['pageContent'],
				':status' => $pageStatus
			]);
		}
	}

	/**
	 * Deletes a page from db
	 * 
	 * @param  int $pageId 
	 * @return boolean      
	 */
	public function delete($pageId) {
		if(isset($_SESSION['role'])) {
			if($_SESSION['role'] == 'admin') {
				$stmt = $this->db->prepare("DELETE FROM pages WHERE id = :page_id");
				return $stmt->execute([
					':page_id' => $pageId,
				]);
			}
		}
	}
}