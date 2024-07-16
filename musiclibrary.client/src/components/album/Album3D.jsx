import React, { useRef, Suspense } from 'react';
import { Canvas, useLoader } from '@react-three/fiber';
import { TextureLoader } from 'three';
import { OrbitControls, CameraControls, GizmoHelper, GizmoViewport, Plane, OrthographicCamera } from '@react-three/drei';
import AlbumModel from '../../../public/AlbumModel';

const Album3D = ({ frontCoverUrl, backCoverUrl }) => {
    const vite = '../../../public/vite.svg'
    const frontCover = frontCoverUrl ? useLoader(TextureLoader, frontCoverUrl) : vite;
    const backCover = backCoverUrl ? useLoader(TextureLoader, backCoverUrl) : frontCover;

    console.log("URLS in Album3D: ", frontCoverUrl, backCoverUrl);
    console.log("Covers in Album3D: ", frontCover, backCover);

    return (
        <div className="album-3d">
            <Canvas>
                <Suspense fallback={null}>
                    <ambientLight intensity={2} />
                    <directionalLight position={[0, 0, 5]} intensity={2} />
                    <OrthographicCamera>
                        <AlbumModel frontCover={frontCover} backCover={backCover} />
                    </OrthographicCamera>
                    <GizmoHelper alignment="bottom-right" margin={[100, 100]}>
                        <GizmoViewport labelColor="white" axisHeadScale={1} />
                    </GizmoHelper>
                    <OrbitControls makeDefault />
                </Suspense>
            </Canvas>
        </div>
    );
};

export default Album3D;
