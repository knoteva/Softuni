<?php

/**
 * AdminController
 */
class Admin extends Main {

	/**
	 * The default method.
	 *
	 */
	public function index() {
		$user = $this->getModel('UserModel');
		if ($user->isAdmin()) {
			Redirect::to('admin/addPost');
		} else {
			Redirect::to('homepage');
		}

	}

	/**
	 * Loads the adminView
	 * Sends information to the adminView on which admin sub-view to load
	 * In this case the sub-view is addPostView
	 *
	 */
	public function addPost() {
		if (!$this->getModel('UserModel')->isAdmin()) {
			Redirect::to('homepage');
		}

		$msg = null;
		$viewData = null;
        $categoriesModel = $this->getModel('CategoryModel');
        $allCategories = $categoriesModel->getCategories();
		if (isset($_POST['postSubmit'])) {
			$post = $this->getModel('PostModel');

			$result = $post->addPost();

			if ($result) {
				$msg = 'Post added successfully.';
			} else {
				$msg = 'Don\'t cheat, bro! Fill in all the blanks.';
			}
		}

		$data = [
			'msg' => $msg,
			'action' => 'addPost',
            'categories' => $allCategories
		];

		$this->getView('adminView', $data);
	}

	/**
	 * Loads the admin panel and specifies the sub-view in the views/admin folder.
	 *
	 * @param  string $thing The thing the admin wants to manage (e.g. posts, pages or categories)
	 */
	public function manage($thing) {
		if (!$this->getModel('UserModel')->isAdmin()) {
			Redirect::to('homepage');
		}
		$msg = null;
		$pageModel = $this->getModel('PageModel');
        $categoryModel = $this->getModel('CategoryModel');
		if (empty($thing)) {
			$this->index();
		} 

		////////////
		//Posts //
		////////////
        else if ($thing[0] == 'posts') {
            $model = $this->getModel('PostModel');
            $allPosts = $model->getPosts();
            $data = [

                'posts' => $allPosts,
            ];

            $this->getView('admin/managePostsView', $data);
        }

		/////////////
		// Pages //
		/////////////
		else if ($thing[0] == 'pages') {
			$pages = $pageModel->getAll();
			if(isset($_POST['pageSubmit'])) {
				$msg = $pageModel->add();
				$msg = $msg ? 'Successfully added new page.' : 'Something went wrong. Please, try again.';

			}

			$data = [
				'msg' => $msg,
				'action' => 'managePages',
				'pages' => $pages
			];

			$this->getView('adminView', $data);
		}

		/////////////////
		// Categories //
		/////////////////
		else if ($thing[0] == 'categories') {
            $categories = $categoryModel->getCategories();
            if(isset($_POST['categorySubmit'])) {
                $msg = $categoryModel->add();
                $msg = $msg ? 'Successfully added new category.' : 'Something went wrong. Please, try again.';

            }

            $data = [
				'msg' => $msg,
				'action' => 'manageCategories',
                'categories' => $categories
			];

			$this->getView('adminView', $data);
		}
	}

	public function delete($input = null) {
		if(count($input) < 2) Redirect::to('homepage'); 

		$node = $input[0];
		$pageId = (int) $input[1];

		/////////////
		// Pages //
		/////////////
		if($node == 'page') {
			if(!isset($_SESSION['role'])) {
				if($pageId == null || $_SESSION['role'] != 'admin') {
					Redirect::to('homepage');
				} 
			} else {
				$pageModel = $this->getModel('PageModel');
				$pageModel->delete($pageId);
				Redirect::to('admin/manage/pages');
			}
		}

		///////////////////////////////////////////////////////////
		//TODO: Add functionalities - delete post and category //
		///////////////////////////////////////////////////////////

        if($node == 'post') {
            if(!isset($_SESSION['role'])) {
                if($pageId == null || $_SESSION['role'] != 'admin') {
                    Redirect::to('homepage');
                }
            } else {
                $pageModel = $this->getModel('PostModel');
                $pageModel->delete($pageId);
                Redirect::to('admin/manage/posts');
            }
        }
		// if($node == 'category') {}
	}

}
