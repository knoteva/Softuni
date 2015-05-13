<?php

/**
 * TagsModel
 */
class TagModel extends MainModel {

	private $tagsTitles = [];
	private $tagsIds = [];

	/**
	 * Parses tags string (separated by comma-space /, /)
	 *
	 * @return boolean
	 */
	public function parseTags() {
		if (isset($_POST['postTags'])) {
			if (!empty(trim($_POST['postTags']))) {
				$this->tagsTitles = explode(", ", filter_input(INPUT_POST, 'postTags'));
			}
		}
	}

	/**
	 * Adds given tags as array to the database
	 *
	 * @var array $tags
	 */
	public function addTags() {
		$isertedTagsIds = [];

		if (!empty($this->tagsTitles)) {
			foreach ($this->tagsTitles as $tag) {
				$tagId = $this->getTagId($tag);
				if ($tagId == false) {
					$query = $this->db->prepare("INSERT INTO tags (title) VALUES (:title)");
					$query->execute([
						':title' => $tag,
					]);
					$insertedTagsids[] = $this->db->lastInsertId();
				} else {
					$insertedTagsids[] = $tagId;
				}
			}
		}

		$this->tagsIds = $insertedTagsids;
	}

	/**
	 * Get tag by id
	 *
	 * @var string $tagName
	 */
	private function getTagId($tagName) {
		$query = $this->db->prepare('SELECT * FROM tags WHERE title = :title');
		$query->execute([
			':title' => $tagName,
		]);
		$result = $query->fetchAll(PDO::FETCH_OBJ);
		return empty(!$result) ? $result[0]->id : false;
	}

	/**
	 * Adds new items to the taxonomy table.
	 * This method needs the id of the post and the tags id's as an array.
	 *
	 * @var int $postId
	 * @var array $tagsIds
	 */
	public function addTaxonomy($postId) {
		if (!empty($this->tagsIds) && $postId) {
			foreach ($this->tagsIds as $tag) {
				$query = 'INSERT INTO taxonomy(post_id, tag_id) VALUES(:post_id, :tag_id)';
				$_query = $this->db->prepare($query);
				$_query->execute([
					':post_id' => $postId,
					':tag_id' => $tag,
				]);
			}
		}

		return false;
	}

	/**
	 * Gets the tags for a specific post
	 * 
	 * @param  int $postId
	 * @return array
	 */
	public function get($postId) {
		$query = 'SELECT tags.id as tag_id, tags.title as tag_title, posts.id as post_id, posts.title as post_title FROM tags ';
		$query.= 'INNER JOIN taxonomy ON tags.id = taxonomy.tag_id ';
		$query.= 'INNER JOIN posts ON posts.id = taxonomy.post_id ';
		$query.= 'WHERE posts.id = :post_id';

		$stmt = $this->db->prepare($query);
		$stmt->execute([
			':post_id' => $postId,
		]);
		$result = $stmt->fetchAll(PDO::FETCH_OBJ);

		return $result;
	}

	public function mostPopularTags() {
		$query = 'SELECT tags.title, COUNT(*) AS tag_magnitude ';
		$query.= 'FROM taxonomy INNER JOIN tags ';
		$query.= 'ON taxonomy.tag_id = tags.id ';
		$query.= 'GROUP BY tag_id ';
		$query.= 'ORDER BY tag_magnitude DESC';

		$stmt = $this->db->query($query);
		return $stmt->fetchAll(PDO::FETCH_OBJ);
	}
}