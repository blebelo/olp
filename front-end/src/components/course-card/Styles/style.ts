// components/styles/HomePageStyle.ts
import { createStyles, css } from "antd-style";

export const useStyles = createStyles({
  heroContainer: css`
    min-height: 100vh;
    background: linear-gradient(135deg, #4ecdc4 0%, #44a08d 100%);
    position: relative;
    overflow: hidden;
    padding: 5rem 1.25rem;
  `,
  decorativeCircleLarge: css`
    position: absolute;
    top: 20%;
    left: 10%;
    width: 6.25rem;
    height: 6.25rem;
    background: rgba(255, 255, 255, 0.1);
    border-radius: 50%;
    z-index: 1;
  `,
  decorativeCircleSmall: css`
    position: absolute;
    top: 60%;
    right: 15%;
    width: 3.75rem;
    height: 3.75rem;
    background: rgba(255, 255, 255, 0.15);
    border-radius: 50%;
    z-index: 1;
  `,
  contentRow: css`
    min-height: 80vh;
    position: relative;
    z-index: 2;
  `,
  textContainer: css`
    text-align: left;
    color: white;
  `,
  mainTitle: css`
    color: white !important;
    font-size: 3.5rem !important;
    font-weight: bold !important;
    margin-bottom: 1.5rem !important;
    line-height: 1.2 !important;
  `,
  subtitleText: css`
    color: rgba(255, 255, 255, 0.9) !important;
    font-size: 1.125rem !important;
    margin-bottom: 2.5rem !important;
    line-height: 1.6 !important;
  `,
  primaryButton: css`
    background-color: #1890ff !important;
    border-color: #1890ff !important;
    height: 3.125rem !important;
    padding: 0 1.875rem !important;
    font-size: 1rem !important;
    font-weight: 500 !important;
    border-radius: 0.5rem !important;
  `,
  sectionTitle: css`
    font-size: 2rem;
    font-weight: 600;
    color: white;
    margin: 3rem 0 1.5rem;
  `,
  courseCard: css`
    border-radius: 1rem;
    overflow: hidden;
    box-shadow: 0 0.25rem 1.25rem rgba(0, 0, 0, 0.1);
  `,
  viewMoreBtn: css`
    background-color: #1890ff !important;
    border-color: #1890ff !important;
    color: #ffffffff !important;
    margin-top: 1rem;
    font-size: 1.1rem;
    padding: 0.6rem 1.5rem;
    border-radius: 0.5rem;
    transition: all 0.3s ease;

    &:hover {
      background-color: #ffffff;
      color: #ffffff !important;
      border-color: #ffffff;
    }
  `,
  image: css `
    object-fit: cover;
    border-top-left-radius: 0.5rem;
    border-top-right-radius: 0.5rem;
  `
});
