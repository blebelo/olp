import { createStyles, css } from "antd-style";

export const useStyles = createStyles({
    Container: css`
        background-color: #9ba8ab;
        min-height: 100vh;
        gap: 2rem;
    `,
    Sider: css`
        padding: 2rem;
        color: #ffffff;
        background-color:#4a5c6a; 
    `,
    Content: css`
        padding: 2rem;
        color: #ffffff;
    `,
    Typography: css`
        color: #ffffff;
        margin-top: 1rem;
        font-size: 1.5rem;
        font-weight: bold;
    `,
    CourseLesson: css`
        color: #ffffff;
        margin-top: 1rem;
        font-size: 1.4rem;
    `,
    Button: css`
        background-color: #ffffff;
        margin-right: 0.5rem;
        margin-top: 1rem;
        margin-bottom: 0.5rem;
        border: none;
        color: #000000;

        &:hover {
            background-color: #11212d !important;
        }
    `,
    LessonItem: css`
        color: #ffffff;
        font-size: 1rem;
        list-style: numeric;
        margin-top: 0.5rem;
        display: flex;
    `,
    ManageButton: css`
        background-color: #11212d;
        margin-right: 0.5rem;
        margin-top: 1rem;
        margin-bottom: 0.5rem;
        border: none;
        color: #ffffff;

        &:hover {
            background-color: #11212d !important;
        }
    `,
    CardContainer: css`
        background-color: #4a5c6a;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        color: #ffffff;
    }
    `,
    CourseDetailsTitle: css`
        color: #000000;
        margin-top: 1rem;
        font-size: 1.5rem;
        font-weight: bold;
    `
})