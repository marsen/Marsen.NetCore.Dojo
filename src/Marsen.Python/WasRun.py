from TestCase import TestCase


class WasRun(TestCase):
    def setup(self):
        self.log = "setUp "

    def tear_down(self):
        self.log = self.log + "tearDown "

    def test_method(self):
        # tracking the method has been called
        self.wasRun = 1
        self.log = self.log + "testMethod "

    def test_broken_method(self):
        raise Exception