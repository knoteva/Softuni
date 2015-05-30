<?php
class CommentModel extends MainModel {
    //list comments
    //delete comments ?

    /**
     * Adds comment to the database
     * 
     * @param string $content The content of the comment
     * @param int $post_id The id of the post
     * @param int $author_id The id of the author
     * @return boolean
     */
    public function addComment($content, $post_id, $author_id) {
        $query = $this->db->prepare('INSERT INTO comments(content, post_id, author_id) VALUES (:content, :post_id, :author_id)');
        return $query->execute([':content'=> $content, ':post_id'=> $post_id, ':author_id'=> $author_id]);
    }

    /**
     * Lists all posts
     * 
     * @param  int $post_id 
     * @return boolean
     */
    public function listComments($post_id){
        $query = $this->db->prepare("SELECT comments.id, comments.content, comments.post_id, comments.author_id, users.username as author_username, users.firstname as author_firstname, users.lastname as author_lastname FROM comments INNER JOIN users ON comments.author_id = users.id WHERE comments.post_id = :post_id");
        $query->execute(['post_id'=> $post_id]);
        return $query->fetchAll(PDO::FETCH_OBJ);
    }

    /**
     * Get all comments a logged user has posted
     * 
     * @return boolean/array The array of comments or false, if no comments.
     */
    public function getMine() {
        $stmt = $this->db->prepare("SELECT comments.id, comments.content, comments.post_id, comments.author_id, users.username as author_username, users.firstname as author_firstname, users.lastname as author_lastname, posts.id as post_id, posts.title as post_title FROM comments INNER JOIN users ON comments.author_id = users.id INNER JOIN posts ON comments.post_id = posts.id WHERE comments.author_id = :author_id");
        $stmt->execute([
            ':author_id' => $_SESSION['id']
        ]);
        $results = $stmt->fetchAll(PDO::FETCH_OBJ);
        
        if(empty($results)) return false;

        return $results;
    }
}

