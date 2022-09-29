#if UNITY_EDITOR
using SLZ.Marrow.Warehouse;
using UnityEngine;

namespace SLZ.Marrow.Utilities
{
    public class EditorPreviewMeshGizmo : EditorMeshGizmo
    {
        public static EditorPreviewMeshGizmo Draw(string id, GameObject targetGameObject, SpawnableCrateReference crateReference, Material material, bool hidePreviewMesh = false, bool showInPlayMode = false)
        {
            Mesh previewMesh = null;
            Bounds bounds = default;
            if (!Application.isPlaying)
            {
                if (!hidePreviewMesh)
                {
                    if (crateReference != null && crateReference.EditorCrate != null && crateReference.EditorCrate.PreviewMesh != null && crateReference.EditorCrate.PreviewMesh.EditorAsset != null)
                    {
                        previewMesh = crateReference.EditorCrate.PreviewMesh.EditorAsset;
                    }
                    else
                    {
                        previewMesh = MarrowSDK.VoidMesh;
                    }
                }

                if (crateReference != null && crateReference.EditorCrate != null)
                {
                    bounds = crateReference.EditorCrate.ColliderBounds;
                }
            }

            return Draw<EditorPreviewMeshGizmo>(id, targetGameObject, previewMesh, material, bounds, showInPlayMode);
        }

    }
}
#endif