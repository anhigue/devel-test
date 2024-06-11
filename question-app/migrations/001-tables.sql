CREATE TABLE users (
    id INT PRIMARY KEY,
    username VARCHAR NOT NULL,
    pass VARCHAR NOT NULL,
    email VARCHAR NOT NULL,
    created_at DATETIME CONSTRAINT DF_users_created_at DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE survey_head (
    id INT PRIMARY KEY,
    user_id INT NOT NULL,
    title VARCHAR NOT NULL,
    description TEXT,
    is_in_review BIT CONSTRAINT DF_survey_head_is_in_review DEFAULT 0,
    created_at DATETIME CONSTRAINT DF_survey_head_created_at DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id)
);  

CREATE TABLE survey_questions (
    id INT,
    survey_id INT NOT NULL,
    question_title VARCHAR NOT NULL,
    question_type VARCHAR NOT NULL,
    is_required BIT CONSTRAINT DF_survey_questions_is_required DEFAULT 0,
    show_question BIT CONSTRAINT DF_survey_questions_show_question DEFAULT 1,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id, survey_id),
    FOREIGN KEY (survey_id) REFERENCES survey_head(id)
);

CREATE TABLE survey_answers (
    id INT,
    survey_id INT NOT NULL,
    question_id INT NOT NULL,
    answer TEXT,
    created_at DATETIME CONSTRAINT DF_survey_answers_created_at DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id, survey_id, question_id),
    FOREIGN KEY (survey_id) REFERENCES survey_head(id),
);
