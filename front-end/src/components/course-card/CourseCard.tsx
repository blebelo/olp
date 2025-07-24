import { Card } from 'antd';
import Image from 'next/image';
import { useStyles } from './Styles/style';

export type CourseType = {
  id: string;
  name: string;
  topic: string;
  description: string;
  thumbnail: string;
  isPublished?: boolean;
};

interface CourseCardProps {
  course: CourseType;
  onClick?: (course: CourseType) => void;
  onPublishToggle?: (courseId: string, isPublished: boolean) => void;
}

const CourseCard: React.FC<CourseCardProps> = ({ course, onClick, onPublishToggle }) => {
  const { styles } = useStyles();

  return (
    <Card 
      className={styles.courseCard}
      hoverable 
      onClick={() => onClick?.(course)}
      cover={
        <div style={{ position: 'relative', width: '100%', height: '10rem' }}>
          <Image
            alt={course.name}
            src={course.thumbnail}
            fill
            className={styles.image}
            sizes="(max-width: 768px) 100vw, 33vw"
          />
        </div>
      }
    >
      <Card.Meta
        title={course.name}
        description={
          <>
            <p><strong>Topic:</strong> {course.topic}</p>
            <p>{course.description}</p>
            <p><strong>Status:</strong> {course.isPublished ? 'Published' : 'Unpublished'}</p>
            {typeof course.isPublished === 'boolean' && (
              <button
                className={styles.publishButton}
                onClick={e => {
                  e.stopPropagation();
                  onPublishToggle?.(course.id, !course.isPublished);
                }}
              >
                {course.isPublished ? 'Unpublish' : 'Publish'}
              </button>
            )}
          </>
        }
      />
    </Card>
  );
};

export default CourseCard;