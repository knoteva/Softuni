<?php

class SearchModel extends MainModel {

	/**
	 * Performs a search action, searching in posts titles and contents
	 * 
	 * @param  string $term
	 */
	public function post($term) {
		// $term = preg_replace("/[^0-9A-Za-z]/i", "", $term);
		$query = "SELECT * FROM posts WHERE status = 1 AND (content LIKE concat('%', :content, '%') OR title LIKE concat('%', :title, '%'))";
		
		$stmt = $this->db->prepare($query);
		$stmt->execute([
			':content' => $term,
			':title' => $term
		]);
		$results = $stmt->fetchAll(PDO::FETCH_OBJ);
		return !empty($results) ? $results : null;
	}

	/**
	 * Returns a list of posts, containing the tag specified.
	 * 
	 * @param  string $tagName
	 * @return array
	 */
	public function searchByTag($tagName)
	{
		$tagName = trim(htmlspecialchars($tagName));
		$query = 'SELECT posts.id, posts.title FROM tags ';
		$query.= 'INNER JOIN taxonomy ON tags.id = taxonomy.tag_id ';
		$query.= 'INNER JOIN posts ON taxonomy.post_id = posts.id ';
		$query.= 'WHERE tags.title = :tag AND status = 1';

		$stmt = $this->db->prepare($query);
		$stmt->execute([
			':tag' => $tagName
		]);
		$posts = $stmt->fetchAll(PDO::FETCH_OBJ);

		return $posts;
	}

    public function searchByCategory($catName)
    {
        $catName = trim(htmlspecialchars($catName));
        $query = 'SELECT id FROM categories WHERE title=:catName';
        $stmt = $this->db->prepare($query);
        $stmt->execute([
            ':catName' => $catName
        ]);
        $catId = $stmt->fetchAll(PDO::FETCH_OBJ);
        $catId = $catId[0]->id;
        $query = 'SELECT id, title FROM posts ';
        $query.= 'WHERE category_id = :catId AND status = 1';

        $stmt = $this->db->prepare($query);
        $stmt->execute([
            ':catId' => $catId
        ]);
        $posts = $stmt->fetchAll(PDO::FETCH_OBJ);

        return $posts;
    }
}
