class TestCase:
    def __init__(self, name):
        # tracking the setUp has been called
        self.wasRun = None
        self.name = name
        self.log = ""

    def setup(self):
        pass

    def tear_down(self):
        pass

    def run(self, result):
        result.test_started()
        # todo when setUp raise exception
        self.setup()
        # dynamic run the test case
        try:
            method = getattr(self, self.name)
            method()
        except:
            result.test_failed()

        self.tear_down()
        return result