<?php

/**
 * PageController
 */
class Page extends Main {

	/**
	 * The default method
	 *
	 */
	public function index() {
		Redirect::to('homepage');
	}

	/**
	 * Shows a specified page by id
	 *
	 * @param  int $id The id of the page
	 */
	public function show($id) {
		if (empty($id)) {
			Redirect::to('homepage');
		} else {
			$page = $this->getModel('PageModel');
			$page = $page->open($id[0]);
			$this->getView('pageView', $page);
		}

	}
}