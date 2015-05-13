<?php

/**
 * HomeController.
 */
class Home extends Main {

	/**
	 * The default method.
	 *
	 */
	public function index() {
		if(isset($_POST['searchBar'])) {
			Redirect::to('search/master/?term=' . rawurlencode(rawurlencode($_POST['searchBar'])));
		}

		$home = $this->getModel('PostModel');
		$tagModel = $this->getModel('TagModel');
		$categoryModel = $this->getModel('CategoryModel');

		$allVisiblePosts = $home->getPosts();
		$mostPopularTags = $tagModel->mostPopularTags();
        $allCategories = $categoryModel->getCategories();

		$data = [
			'posts' => $allVisiblePosts,
			'tags' => $mostPopularTags,
            'categories' => $allCategories
		];

		$this->getView('homeView', $data);
	}
}
