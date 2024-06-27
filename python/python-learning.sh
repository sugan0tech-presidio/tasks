session_root "~/Documents/GitHub/tasks/python/"

if initialize_session "python-learning"; then

  new_window "code"
  run_cmd "nvim"
  split_v 10
  run_cmd "tty-clock"
  select_pane 1

  new_window "terminal"
  run_cmd "nu"

  new_window "htop"

  select_window 1

fi

finalize_and_go_to_session

