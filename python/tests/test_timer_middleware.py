from unittest.mock import patch, MagicMock

from pyapi.timer_middleware import TimerMiddleware


def test_timer_middleware():
    with patch('builtins.print') as mock_print:
        get_response = MagicMock()
        the_request = 'a_request'
        timer_middleware = TimerMiddleware(get_response)

        # invoking the __call__ method
        timer_middleware(request=the_request)

        assert mock_print.call_count == 1
        get_response.assert_called_once_with(the_request)
